import datetime

import sqlalchemy as db
from sqlalchemy import exc, text

import logging
from enum import Enum, auto

class LP_STATUS(Enum):
	NOT_FOUND = auto()	
	INIT = auto()	
	VALID = auto()	
	INVALID = auto()	

class PGDB:

	def __init__(self,conn_string):
		self.engine = db.create_engine(conn_string)
		self.conn = self.engine.connect()
		self.metadata = db.MetaData(schema='Kali')

		self.match_ledger = db.Table('match_ledger', self.metadata,
			db.Column('match_id',db.Integer,db.Sequence('match_seq'),primary_key=True,nullable=False),
			db.Column('discord_id',db.BigInteger,nullable=False),
			db.Column('side',db.String(7),nullable=False),
			db.Column('winning_side',db.String(7),nullable=True),
			db.Column('creation_time',db.DateTime,nullable=False))

		self.bet_ledger = db.Table('bet_ledger', self.metadata,
			db.Column('match_id',db.Integer,nullable=False),
			db.Column('gambler_id',db.BigInteger,nullable=False),
			db.Column('bet_side',db.String(7),nullable=False),
			db.Column('amount',db.BigInteger,nullable=False))

		self.balance_ledger = db.Table('balance_ledger',self.metadata,
			db.Column('discord_id',db.BigInteger,primary_key=True,nullable=False),
			db.Column('tokens',db.BigInteger,nullable=False))

		self.live_lobbies = db.Table('live_lobbies', self.metadata,
			db.Column('lobby_id',db.BigInteger,nullable=False))

		self.lobby_message = db.Table('lobby_message', self.metadata,
			db.Column('lobby_id',db.BigInteger,nullable=False,primary_key=True),
			db.Column('message_id',db.BigInteger,nullable=False))

		self.live_matches = db.Table('live_matches', self.metadata,
			db.Column('query_time',db.BigInteger,nullable=False),
			db.Column('activate_time',db.BigInteger,nullable=False),
			db.Column('deactivate_time',db.BigInteger,nullable=False),
			db.Column('server_steam_id',db.BigInteger,nullable=False),
			db.Column('lobby_id',db.BigInteger,nullable=False),
			db.Column('league_id',db.Integer,nullable=False),
			db.Column('lobby_type',db.Integer,nullable=False),
			db.Column('game_time',db.Integer,nullable=False),
			db.Column('delay',db.Integer,nullable=False),
			db.Column('spectators',db.Integer,nullable=False),
			db.Column('game_mode',db.Integer,nullable=False),
			db.Column('average_mmr',db.Integer,nullable=False),
			db.Column('match_id',db.BigInteger,nullable=False),
			db.Column('series_id',db.Integer,nullable=False),
			db.Column('sort_score',db.Integer,nullable=False),
			db.Column('last_update_time',db.Float,nullable=False),
			db.Column('radiant_lead',db.Integer,nullable=False),
			db.Column('radiant_score',db.Integer,nullable=False),
			db.Column('dire_score',db.Integer,nullable=False),
			db.Column('building_state',db.Integer,nullable=False))

		self.live_players = db.Table('live_players', self.metadata,
			db.Column('match_id',db.BigInteger,nullable=False),
			db.Column('player_num',db.Integer,nullable=False),
			db.Column('account_id',db.BigInteger,nullable=False),
			db.Column('hero_id',db.Integer,nullable=False))

		self.rp_heroes = db.Table('rp_heroes', self.metadata,
			db.Column('lobby_id',db.BigInteger,nullable=False,primary_key=True),
			db.Column('steam_id',db.BigInteger,nullable=False,primary_key=True),
			db.Column('param0',db.String,nullable=True,primary_key=True),
			db.Column('param1',db.String,nullable=True,primary_key=True),
			db.Column('param2',db.String,nullable=True))

		self.metadata.create_all(self.engine)

	def replace_live(self,lobbies):
		begin_statement = '''BEGIN WORK;
LOCK TABLE "Kali".live_lobbies IN ACCESS EXCLUSIVE MODE;'''
		delete = str(self.live_lobbies.delete())+';'
		end_statement = text('COMMIT WORK;')
		lobby_template = text('INSERT INTO "Kali".live_lobbies VALUES (:lobby_id)')
		lobby_statements = []
		for l in lobbies:
			lobby_statements.append(str(lobby_template.bindparams(lobby_id = l).compile(compile_kwargs={"literal_binds": True}))+';')
		lobby_statement = '\n'.join(lobby_statements)
		lock_statement = '''{}
{}
{}
{}'''.format(begin_statement,delete,lobby_statement,end_statement)
		print(lock_statement)
		result = self.conn.execute(lock_statement)
		print('result rowcount:',result.rowcount)
		
	def get_live(self):
		ll = self.live_lobbies
		q = db.select([ll])
		#logging.warning('executing: {}'.format(q))
		result = self.conn.execute(q).fetchall()
		#logging.warning('result: {}'.format(result))
		return result

	def insert_message(self,lobby_id,message_id):
		lm = self.lobby_message
		insert = lm.insert().values(lobby_id=lobby_id,message_id=message_id)
		result = self.conn.execute(insert)

	def select_message(self,lobby_id):
		lm = self.lobby_message
		s = db.select([lm.c.message_id]).where(lm.c.lobby_id == lobby_id)
		return self.conn.execute(s).fetchone()

	def select_lm(self,lobby_id,last_update_time=None,query_only=False):
		lm = self.live_matches
		if last_update_time == None:
			s = db.select([lm]).where(lm.c.lobby_id == lobby_id)
		else:
			s = db.select([lm]).where(db.and_(lm.c.lobby_id == lobby_id,
											  lm.c.last_update_time >= last_update_time))
		if query_only:
			return s
		else:
			results = self.conn.execute(s).fetchall()
			return results

	def insert_lm(self,row):
		lm = self.live_matches
		insert = lm.insert().values(**row)
		result = self.conn.execute(insert)
	
	def insert_lp(self,players):
		lp = self.live_players
		insert = lp.insert().values(players)
		result = self.conn.execute(insert)

	def update_lp(self,players):
		lp = self.live_players
		error = False
		for p in players:
			update = lp.update().values(hero_id = p['hero_id']).where(db.and_(lp.c.match_id == p['match_id'],
																			   lp.c.player_num == p['player_num'],
																			   lp.c.account_id == p['account_id']))
			result = self.conn.execute(update)
			if result.rowcount != 1:
				error = True
				logging.warning('update lp returned {} results'.format(results.rowcount))
		if error:
			return LP_STATUS.INVALID
		else:
			return LP_STATUS.VALID

	def check_lp(self,match_id):
		lp = self.live_players
		s = db.select([lp.c.hero_id]).where(lp.c.match_id == match_id)
		logging.info('executing: {}'.format(s))
		if (result := self.conn.execute(s).fetchall()):
			if len(result) != 10:
				logging.info('Unexpected number of players in match_id {}'.format(match_id))
				return LP_STATUS.INVALID
			elif any(map(lambda x: x == 0,map(lambda x: x['hero_id'],result))):
				return LP_STATUS.INIT
			else:
				return LP_STATUS.VALID
		else:
			logging.info('no live players found for match_id = {}'.format(match_id))
			return LP_STATUS.NOT_FOUND

	def insert_rp(self,row):
		rp = self.rp_heroes
		s = db.select([rp]).where(db.and_(rp.c.lobby_id == row['lobby_id'],
										  rp.c.steam_id == row['steam_id']))
		logging.info('executing: {}'.format(s))
		if (result := self.conn.execute(s).fetchone()):
			logging.info('result: {}'.format(result))
			return False
		else:
			logging.info('result: {}'.format(result))
			insert = rp.insert().values(**row)
			logging.info('inserting with: {}'.format(insert))
			result = self.conn.execute(insert)
			return True

	def check_balance(self,discord_id):
		s = db.select([self.balance_ledger]).where(self.balance_ledger.c.discord_id == discord_id)
		if (result := self.conn.execute(s).fetchone()):
			return result.tokens
		else:
			insert = self.balance_ledger.insert().values(discord_id=discord_id,tokens=1000)
			result = self.conn.execute(insert)
			return 1000
	
	def start_match(self,discord_id,side):
		now = dt.datetime.now()
		ml = self.match_ledger
		s = db.select([ml.c.discord_id,ml.c.winning_side,ml.c.creation_time])\
			.where(db.and_(	self.match_ledger.c.discord_id == discord_id, 
							self.match_ledger.c.winning_side == None))
		if (result := self.conn.execute(s).fetchone()):
			return False,result.creation_time
		else:
			insert = self.match_ledger.insert().values(discord_id=discord_id,side=side,creation_time=now)
			result = self.conn.execute(insert)
			return True,now

	def set_winner(self,discord_id,winning_side):
		raise NotImplemented
		ml = self.match_ledger
		s = db.select([ml.c.discord_id,ml.c.winning_side,ml.c.creation_time])\
			.where(db.and_(	self.match_ledger.c.discord_id == discord_id, 
							self.match_ledger.c.winning_side == None))
		if (result := self.conn.execute(s).fetchone()):
			return False,result.creation_time
		else:
			insert = self.match_ledger.insert().values(discord_id=discord_id,side=side,creation_time=now)
			result = self.conn.execute(insert)
			return True,now
