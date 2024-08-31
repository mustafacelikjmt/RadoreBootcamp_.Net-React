import { useState } from "react";
function StateHook() {

    const [adet, adetiDegistir] = useState(0);
    // this.state = {
    //adet : 0
    //}
    const abc = () => adetiDegistir(adet + 1)
    return (
        <div>
            <p >{adet} kere tıkladınız</p>
            <button onClick={abc}>Tıkla</button>
        </div>
    )
}
export default StateHook;