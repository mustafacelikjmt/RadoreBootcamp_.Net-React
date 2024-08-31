import { Component } from "react";
import tutorialService from "../service/tutorial.service";
import { Link } from "react-router-dom";

export default class TutorialList extends Component {

    constructor(props) {
        super(props);
        this.selectedTutorial = this.selectedTutorial.bind(this)
        this.state = { // içinde bi çok şeyi saklayabilmek için
            tutorials: [],
            currentTutorial: null,
            currentIndex: -1,
            searchInput: ''
        }
        this.searchTitleByKeyUp = this.searchTitleByKeyUp.bind(this)
        this.searchOnChange = this.searchOnChange.bind(this)
        this.selectedTutorial = this.selectedTutorial.bind(this)
    }

    componentDidMount() { //sayfa ilk yüklendiğinde
        console.log("Tutorial list sayfası yüklendi")
        this.tutoriallariGetir()
    }

    tutoriallariGetir() {
        tutorialService.getAll().then(response => {
            this.setState({ //api den gelen veriyi tutorial array ine aktardık
                tutorials: response.data
            })
            console.log(response.data)
        }).catch(hata => {
            console.log("Hata oluştu: " + hata)
        })
    }

    searchTitle() {
        console.log("Ara butonuna tıklandı")
    }

    selectedTutorial(tutorial, index) {
        this.setState({
            currentTutorial: tutorial,
            currentIndex: index
        })
    }

    searchTitlee(e) {
        e.preventDefault();
        tutorialService.findByTitle(this.state.searchInput).then((response) => {
            this.setState({
                tutorials: response.data,
            });
            console.log(response.data);
        });
    }
    searchTitleByKeyUp(e) {
        e.preventDefault();
        setTimeout(() => {
            tutorialService.findByTitle(this.state.searchInput).then((response) => {
                this.setState({
                    tutorials: response.data,
                });
                console.log(response.data);
            });
        }, 300)
    }

    searchOnChange = (e) => {
        this.setState({
            searchInput: e.target.value
        })
    }

    render() {
        const { tutorials, currentTutorial, currentIndex, searchInput } = this.state
        return (
            <div className="list row">
                <div className="col-md-8">
                    <div className="input-group mb-3">
                        <input text="text" className="form-control" placeholder="Başlığa göre ara"
                            value={searchInput}
                            onChange={this.searchOnChange}
                            onKeyUp={this.searchTitleByKeyUp} />
                        <div className="input-group-append">
                            <button onClick={this.searchTitleByKeyUp} className="btn btn-success" type="button">Ara</button>
                        </div>
                    </div>
                </div>
                <div className="col-md-6">
                    <ul className="list-group">
                        <h4>Tutorial Listesi</h4>
                        {tutorials && tutorials.map((tutorial, index) => (
                            <li className={"list-group-item " + (index === currentIndex ? "active" : "")}
                                onClick={() => this.selectedTutorial(tutorial, index)} key={index}>
                                {tutorial.title}
                            </li>
                        ))}
                    </ul>
                </div>
                <div className="col-md-6">
                    {currentTutorial ? (
                        <div>
                            <h4>Tutorial Detay</h4>
                            <div><label><strong>Title: </strong></label>{" "}{currentTutorial.title}</div>
                            <div><label><strong>Completed: </strong>{currentTutorial.completed ? "Yes" : "No"}</label></div>
                            <Link to={"/tutorials/" + currentTutorial.id} className="btn btn-success">Detaya git</Link>
                        </div>
                    ) : (
                        <p>Lütfen bir tutorial seçiniz</p>
                    )}
                </div>
            </div>
        )
    }
}