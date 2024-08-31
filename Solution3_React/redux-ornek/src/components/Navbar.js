import React from 'react';
import { Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css"

const Navbar = (props) => {
    return (
        <nav class="navbar navbar-expand-lg bg-body-tertiary">
            <div class="container-fluid">
                <a className="navbar-brand" to="/">Radore</a>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                    <div class="navbar-nav">
                        <Link className="nav-link active" aria-current="page" to="/">Home</Link>
                        <Link className="nav-link" to="/about">Hakkımızda</Link>
                        <Link className="nav-link" to="/contact">Bize Ulaşın</Link>
                    </div>
                </div>
            </div>
        </nav>
    )
}
export default Navbar;