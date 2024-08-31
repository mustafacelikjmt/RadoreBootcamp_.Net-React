import React, { Component } from "react";
import { connect } from 'react-redux';
import { deletePost } from "../Actions/deleteAction";

class Home extends Component {
    deleteClicked = evt => {
        console.log(evt.target.id);
        this.props.deletePost(evt.target.id);
    }
    render() {
        const { gelenPostlar } = this.props;
        const postListesi = gelenPostlar.length ? ( // kaç tane post varsa onu dönücek
            gelenPostlar.map(post => {
                return (
                    <div className="post card">
                        <div className="card-content">
                            <span className="cart-title red-text">
                                {post.title}
                            </span>
                            <p>{post.body}</p>
                        </div>
                        <button onClick={this.deleteClicked} className="btn btn-danger" id={post.id}>Sil</button>
                    </div>
                )
            })
        ) : (
            <div className="center">
                şu an veri yok
            </div>
        )
        return (
            <div>
                <div className="home container">
                    {postListesi}
                </div>
            </div>
        )
    }
}
//state içindeki verileri home componentine taşımamızı sağlayacak
const mapStatetoProps = (state) => {
    return {
        gelenPostlar: state.posts
    }
    //state içindeki postları gelenPostlar objesine aktardık
}
const mapDispatchToProps = (dispatch) => {
    return {
        deletePost: (id) => dispatch(deletePost(id))
    }
}

export default connect(mapStatetoProps, mapDispatchToProps)(Home);