import React from "react";
import Header from '../../components/Common/Header';
import Banner from '../../components/Common/Banner';
import ProductDetailsTwos from '../../components/Common/ProductDetails/ProductDetailsTwo'
import Footer from "../../components/Common/Footer";
import LiveSupport from "../../components/LiveSupport/Index";

const ProductDetailsTwo = () => {
    return (
        <>
            <Header />
            <Banner title="Ürün Detay" />
            <ProductDetailsTwos />
            <LiveSupport />
            <Footer />
        </>
    )
}
export default ProductDetailsTwo