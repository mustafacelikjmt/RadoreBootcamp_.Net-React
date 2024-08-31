import { Component } from "react";
import tutorialService from "../service/tutorial.service";

export default class AddTutorial extends Component {
    constructor(props) {
        super(props);
        this.state = {
            id: null,
            title: "",
            completed: false
        }
        this.onChangeTitle = this.onChangeTitle.bind(this)
        this.onChangeCompleted = this.onChangeCompleted.bind(this)
        this.kaydet = this.kaydet.bind(this)
    }

    onChangeTitle(e) {
        console.log(e.target.value)
        this.setState({
            title: e.target.value
        })
    }
    onChangeCompleted(e) {
        console.log(e.target.value)
        this.setState({
            completed: e.target.value
        })
    }

    kaydet() {
        console.log("Kaydet tıklandı")
        var kaydedilecekTutorial = {
            title: this.state.title,
            completed: this.state.completed
        }
        tutorialService.create(kaydedilecekTutorial).then(kaydedilen => {
            console.log(kaydedilecekTutorial.data)
            console.log("Başarılı")
            window.location.href = "/tutorials"
        }).catch(hata => {
            console.log("Hata: " + hata)
        })
    }


    render() {
        return (
            <div className="submit-form">
                <div className="form-group">
                    <label htmlFor="title">Title: </label>
                    <input type="text" className="form-control" id="title" required onChange={this.onChangeTitle}></input>
                </div>
                <br />
                <div className="form-group">
                    <label htmlFor="completed">Completed: </label>
                    <select className="form-control" onChange={this.onChangeCompleted}>
                        <option value={"true"}>Yes</option>
                        <option value={"false"}>No</option>
                    </select>
                </div>
                <br />
                <button className="btn btn-success" onClick={() => this.kaydet()}>Kaydet</button>
            </div>
        )
    }
}