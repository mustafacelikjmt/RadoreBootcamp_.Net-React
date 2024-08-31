import httpCommon from "../http-common"

class TutorialDataService {

    getAll() { //array şeklinde tutorial datayı dönücek
        return httpCommon.get("/todos")
    }

    getDetail(id) {
        return httpCommon.get(`/todos/${id}`)
    }

    update(id, data) {
        console.log("güncellenecek tutorial id" + id)
        console.log("güncellenecek tutorial id" + data)
        return httpCommon.put(`/todos/${id}`, data)
    }

    delete(id) {
        return httpCommon.delete(`/todos/${id}`)
    }

    create(data) {
        console.log(data)
        return httpCommon.post("/todos", data)
    }

    findByTitle(title) {
        return httpCommon.get(`tutorials?title=${title}`)
    }

}
export default new TutorialDataService()