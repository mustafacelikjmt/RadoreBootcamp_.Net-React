import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import Swal from "sweetalert2";
import { fetchAllProducts } from "../data/getProduct";

// Create an async thunk for fetching product data
export const fetchProductData = createAsyncThunk(
    'products/fetchProductData',
    async () => {
        const response = await fetchAllProducts(); // API çağrısı yapılır
        return response; // Dönen veri burada işlenir
    }
);

const productsSlice = createSlice({
    name: 'products',
    initialState: {
        products: [],
        carts: [],
        favorites: [],
        single: null,
        status: 'idle',
        error: null
    },
    reducers: {
        AddToCart: (state, action) => {
            let { id } = action.payload;
            let sepeteEklenecekUrun = state.carts.find(item => item.id === parseInt(id))
            if (sepeteEklenecekUrun === undefined) {
                let item = state.products.find(item => item.id === parseInt(id))
                item.quantity = 1
                state.carts.push(item)
                Swal.fire({
                    title: 'Başarılı',
                    text: "Ürün sepete eklendi!",
                    icon: 'success',
                    showConfirmButton: false,
                    timer: 2000
                })
            }
        },
        getProductById: (state, action) => {
            let { id } = action.payload;
            let urunDetay = state.products.find(item => item.id === parseInt(id))
            state.single = urunDetay
        },
        updateCart: (state, action) => {
            let { val, id } = action.payload;
            state.carts.forEach(item => {
                if (item.id === parseInt(id)) {
                    item.quantity = val
                }
            })
        },
        removeCart: (state, action) => {
            let { id } = action.payload;
            let sepetinOnSonHali = state.carts.filter(item => item.id !== parseInt(id))
            state.carts = sepetinOnSonHali
        },
        clearCart: (state) => {
            state.carts = []
        },
        addToFavorites: (state, action) => {
            let { id } = action.payload;
            let item = state.favorites.find(item => item.id === parseInt(id))
            if (item === undefined) {
                let urunFavori = state.products.find(item => item.id === parseInt(id))
                urunFavori.quantity = 1
                state.favorites.push(urunFavori)
                Swal.fire({
                    title: 'Başarılı',
                    text: 'İlgili ürün favorilere eklenmiştir',
                    icon: 'success'
                })
            } else {
                Swal.fire('Başarsız', 'İlgili ürün favorilere eklenemedi', 'warning')
            }
        },
        removeToFav: (state, action) => {
            let { id } = action.payload;
            let favorilerinOnSonHali = state.favorites.filter(item => item.id !== parseInt(id))
            state.favorites = favorilerinOnSonHali
        },
        clearFav: (state) => {
            state.favorites = []
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(fetchProductData.pending, (state) => {
                state.status = 'loading';
            })
            .addCase(fetchProductData.fulfilled, (state, action) => {
                state.status = 'succeeded';
                state.products = action.payload;
                state.carts = action.payload.slice(2, 6);
                state.favorites = action.payload.slice(1, 4);
            })
            .addCase(fetchProductData.rejected, (state, action) => {
                state.status = 'failed';
                state.error = action.error.message;
            });
    }
});

export const {
    AddToCart,
    getProductById,
    updateCart,
    removeCart,
    clearCart,
    addToFavorites,
    removeToFav,
    clearFav
} = productsSlice.actions;

export default productsSlice.reducer;