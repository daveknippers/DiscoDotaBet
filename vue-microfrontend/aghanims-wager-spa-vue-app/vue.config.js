const path = require('path');
const CopyWebpackPlugin = require('copy-webpack-plugin');

module.exports = {
  configureWebpack: {
    devServer: {
      https: true,
      headers: {
        "Access-Control-Allow-Origin": "*"
      },
      allowedHosts: "all",
      port: 8080,
      proxy: {
        '/api': {
          target: 'https://aghanimswager.com',
          changeOrigin: true,
          pathRewrite: {
            '^/api': '/api'
          },
          onProxyReq(proxyReq, req, res) {
            proxyReq.setHeader('Access-Control-Allow-Origin', '*');
            proxyReq.setHeader('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE, OPTIONS');
            proxyReq.setHeader('Access-Control-Allow-Headers', 'X-Requested-With, content-type, Authorization');
          }
        }
      },
      server: "localhost"
    },
    output: {
      libraryTarget: "system", 
      filename: "js/aghanims-wager-spa-vue-app.js"
    },
    plugins: [
      new CopyWebpackPlugin({
        patterns: [
          { from: 'src/assets/*', to: 'assets/[name][ext]'},
        ]
      })
    ]
  },
  filenameHashing: false
};
