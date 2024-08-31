function yazdir() {
    const meyveler = ["Elma", "Armut", "Portakal", "Mandalina"]
    console.log(...meyveler)
}

function kopyalama() {
    let meyveler = ["Elma", "Armut", "Portakal", "Karpuz"]
    let meyveler_copy = [...meyveler] //bu şekilde kopyaladığında referansını değil değerini kopyalıyor
    console.log(meyveler_copy)
    meyveler.push("çilek")
    console.log(meyveler)
    console.log(meyveler_copy)
}

function NesneKopyalama() {
    const user = {
        name: "ibrahim",
        surname: "gökyar"
    }
    const userCopy = { ...user }
    console.log(userCopy)
    user.age = 45
    console.log(user)
    console.log(userCopy)
}

function DiziBirlestirme() {
    const erkekIsimleri = ["Hakan", "Metin"]
    const kadınIsimleri = ["Leyla", "Canan"]
    const tumIsimler = [...erkekIsimleri, ...kadınIsimleri]
    console.log(tumIsimler)
}

function ObjeBirlestirme() {
    const kullanici = {
        adi: "ibrahim",
        soyadi: "gokyar"
    }

    const evcilHayvanlar = {
        kopek: "abd",
        kediler: ["Tekir", "Boncuk"]
    }

    const kullaniciDetay = { ...kullanici, ...evcilHayvanlar }
    console.log(kullaniciDetay)
}

function kareAl(...sayilar) {
    return sayilar.map(sayi => sayi * sayi)
}

function SonsuzParametre() {
    console.log(kareAl(3, 5, 7, 11, 22, 33))
}

function KarakterYazdirma() {
    let userName = "ibrahimGokyar"
    let chars = [...userName]
    console.log(chars)
}

function Destructuring() {
    const person2 = {
        adi: "ibrahimgokyar",
        age: 46,
        occupation: "developer",
        skills: "Csharp,java"
    }
    const { adi, age, ...digerleri } = person2
    console.log(digerleri)
    console.log(`Diğerleri: ${digerleri.skills}`)
}