import { Component } from "react";
import tutorialService from "../service/tutorial.service";
import { withRouter } from "../common/with-router"

class TutorialDetail extends Component {
    constructor(props) {
        super(props);
        this.state = {
            guncellenecekTutorial: {
                id: null,
                title: "",
                completed: false
            }
        }
        this.onChangeTitle = this.onChangeTitle.bind(this) //bu bind(this) fonksiyonun this ini manuel olarak ayarlar
        this.onChangeCompleted = this.onChangeCompleted.bind(this) //this artık bileşeni ifade ediyor doğru şekilde
        this.guncelle = this.guncelle.bind(this)
        this.sil = this.sil.bind(this)
    }

    componentDidMount() {
        console.log("bir önceki sayfadan gelen id: " + this.props.router.params.id)
        this.tutorialDetayiGetir(this.props.router.params.id)
    }

    tutorialDetayiGetir(id) {
        tutorialService.getDetail(id).then(gelenTutorialDetay => {
            this.setState({
                guncellenecekTutorial: gelenTutorialDetay.data
            })
        }).catch(hata => {
            console.log("Hata oluştu: " + hata)
        })
    }

    onChangeTitle(e) {
        const title = e.target.value
        console.log(title)
        this.setState(function (prevState) {
            return {
                guncellenecekTutorial: {
                    ...prevState.guncellenecekTutorial,
                    title: title
                }
            }
        })
    }

    onChangeCompleted(e) {
        const completed = e.target.value === "true"
        console.log(completed)
        this.setState(function (prevState) {
            return {
                guncellenecekTutorial: {
                    ...prevState.guncellenecekTutorial,
                    completed: completed
                }
            }
        })
    }

    guncelle(e) {
        tutorialService.update(this.props.router.params.id, this.state.guncellenecekTutorial).then(guncellenecekTutorial => {
            console.log(guncellenecekTutorial)
            this.props.router.navigate("/tutorials")
        }).catch(hata => {
            console.log("hata oluştu: " + hata)
        })
    }

    sil(e) {
        tutorialService.delete(this.state.guncellenecekTutorial.id).then(silinenTutorial => {
            console.log(silinenTutorial.data)
            this.props.router.navigate("/tutorials")
        }).catch(hata => {
            console.log("Hata oluştu: " + hata)
        })
    }

    render() {
        const { guncellenecekTutorial } = this.state
        return (
            <div>
                <div className="edit-form">
                    <h4>Tutorial Detay sayfası</h4>
                    <form>
                        <div className="form-group">
                            <label htmlFor="title">Başlık: </label>
                            <input className="form-control" type="text" id="title"
                                value={guncellenecekTutorial.title}
                                onChange={this.onChangeTitle}></input>
                        </div>
                        <br />
                        <div className="form-group">
                            <label htmlFor="completed">Completed: </label>
                            <select className="form-control" value={guncellenecekTutorial.completed}
                                onChange={this.onChangeCompleted}>
                                <option value={"true"}>Yes</option>
                                <option value={"false"}>No</option>
                            </select>
                        </div>
                        <br />
                        <button type="button" className="btn btn-success" onClick={this.guncelle} >Güncelle</button>
                        <button type="button" className="btn btn-danger" onClick={this.sil}>Sil</button>
                    </form>
                </div>
            </div>
        )
    }
}
export default withRouter(TutorialDetail)