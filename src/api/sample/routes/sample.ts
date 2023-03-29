export default {
  routes: [
    {
     method: 'GET',
     path: '/sample',
     handler: 'sample.exampleAction',
     config: {
       policies: [],
       middlewares: [],
     },
    },
  ],
};
