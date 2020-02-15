import axios from 'axios'
const client = axios.create({
  //baseURL: 'http://textilabeta.pheeca.com/',
  baseURL: window.location.hostname=="localhost"?'http://localhost:56415/':window.location.href,
  json: true
})
export default {
    async execute (method, resource, data) {
      // inject the accessToken for each request
      //let accessToken = await Vue.prototype.$auth.getAccessToken()
      let accessToken ='';
      return client({
        method,
        url: resource,
        data,
        headers: {
          Authorization: `Bearer ${accessToken}`
        }
      }).then(req => {
        return req.data
      })
    },
    searchBlends(value){
      return  this.execute('get', '/api/blend?search='+value)
    },
    getBlends () {
      return  this.execute('get', '/api/blend')
    },
    getBlend (id) {
      return this.execute('get', `/api/blend/${id}`)
    },
    createBlend (data) {
      return this.execute('post', '/api/blend', data)
    },
    updateBlend (id, data) {
      return this.execute('put', `/api/blend/${id}`, data)
    },
    getCounts () {
      return  this.execute('get', '/api/count')
    },
    getCount (id) {
      return  this.execute('get', `/api/count/${id}`)
    },
    createCount (data) {
      return this.execute('post', '/api/count', data)
    },
    updateCount (id, data) {
      return this.execute('put', `/api/count/${id}`, data)
    },
    getPosts () {
      return  this.execute('get', '/api/count/1')
    },
    getPost (id) {
      return this.execute('get', `/posts/${id}`)
    },
    createPost (data) {
      return this.execute('post', '/posts', data)
    },
    updatePost (id, data) {
      return this.execute('put', `/posts/${id}`, data)
    },
    deletePost (id) {
      return this.execute('delete', `/posts/${id}`)
    }
  }