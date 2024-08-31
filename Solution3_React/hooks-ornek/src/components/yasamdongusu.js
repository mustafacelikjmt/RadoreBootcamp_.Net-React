import React from "react";

class YasamDongusu extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            date: new Date(),
            sure: 10
        }
    }

    componentDidMount() {
        //sürekli tekrar etmesini istediğimiz durumları
        //setInterval fonksiyonu içinde tanımlarınz
        this.TimerID = setInterval(
            () => this.tick(),
            1000
        )
    }
    tick() {
        if (this.state.sure === 0) {
            this.componentWillUnmount();
            return;
        }
        this.setState({
            date: new Date(),
            sure: this.state.sure - 1
        })
    }
    componentWillUnmount() {
        clearInterval(this.TimerID);
    }

    componentDidUpdate() {
        console.log(this.state.sure + " değişiyor");
    }

    render() {
        return (
            <div>
                <h1>Yaşam Döngüsü</h1>
                <h2>{this.state.date.toLocaleString()}</h2>
                <h3>Geri Sayım : {this.state.sure}</h3>
            </div>
        )
    }
}
export default YasamDongusu;