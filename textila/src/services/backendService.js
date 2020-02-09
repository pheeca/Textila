import axios from 'axios'
const client = axios.create({
  baseURL: 'http://textilabeta.pheeca.com/',//window.location.hostname=="localhost"?'http://localhost:56415/':window.location.href,
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
    getCounts () {
      return  this.execute('get', '/api/count')
    },
    getBlends () {
      return  this.execute('get', '/api/blend')
    },
    createBlend (data) {
      return this.execute('post', '/api/blend', data)
    },
    
    getBlend (id) {
      return this.execute('get', `/api/Blend/${id}`)
    },
    updateBlend (id, data) {
      return this.execute('put', `/api/Blend/${id}`, data)
    },
    createCount (data) {
      return this.execute('post', '/api/count', data)
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