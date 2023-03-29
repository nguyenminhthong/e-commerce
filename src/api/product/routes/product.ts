export default {
  routes: [
    {
     method: 'GET',
     path: '/product/feature',
     handler: 'product.productFeature',
     config: {
       policies: [],
       middlewares: [],
     },
    },
  ],
};
