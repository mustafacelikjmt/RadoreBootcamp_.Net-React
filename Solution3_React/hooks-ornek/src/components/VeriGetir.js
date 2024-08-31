import { useState, useEffect } from "react"

function VeriGetir() {
    const [usersArray, setData] = useState([]);

    useEffect(() => {
        const getirecekFonksiyon = async () => {

            const gelenData = await fetch(
                "https://jsonplaceholder.org/users"
            );

            if (gelenData.ok) {
                console.log(gelenData);
                const gelenJson = await gelenData.json();
                console.log(gelenJson);
                setData(gelenJson);
            }
        }
        getirecekFonksiyon();
    }, [])

    return (
        <div>
            <ul>
                {usersArray.map((item) =>
                    <li key={item.id}>Adı : {item.firstname} soyadı : {item.lastname}</li>
                )}
            </ul>
        </div>
    )
}
export default VeriGetir;