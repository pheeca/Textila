module.exports = {
  "transpileDependencies": [
    "vuetify"
  ],
  chainWebpack: (config) => {
    config.module
      .rule('images')
      .use('url-loader')
      .tap(options => Object.assign({}, options, { name: '[name].[ext]' }));
  },
  css: {
    extract: {
      filename: 'Content\\[name].css',
      chunkFilename: 'Content\\[name].css',
    },
  },
  configureWebpack: {
    output: {
      filename: 'Scripts\\[name].js',
      chunkFilename: 'Scripts\\[name].js',
    }
  }
}