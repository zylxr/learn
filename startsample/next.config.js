module.exports = {
    async redirects() {
      return [
        // Basic redirect
        {
          source: '/redirect/about',
          destination: '/',
          permanent: true,
        },
        // // Wildcard path matching
        // {
        //   source: '/redirect/:slug',
        //   destination: '/posts/:slug',
        //   permanent: true,
        // },
      ]
    },
  }