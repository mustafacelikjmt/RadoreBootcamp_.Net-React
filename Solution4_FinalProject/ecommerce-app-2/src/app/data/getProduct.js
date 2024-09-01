const API_URL = 'https://localhost:44355/api/products';

// Tüm ürünleri çeken fonksiyon
export const fetchAllProducts = async () => {
    try {
        const response = await fetch(API_URL);
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();

        if (data.isSuccess) {
            return data.result.map(item => (createProductModel(item)));
        } else {
            throw new Error('Data fetch was not successful');
        }
    } catch (error) {
        console.error('Error fetching all products:', error);
        throw error;
    }
};

// Belirli bir ID'ye sahip ürünü çeken fonksiyon
export const fetchProductById = async (id) => {
    try {
        const response = await fetch(`${API_URL}/${id}`);
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();

        if (data.isSuccess) {
            const item = data.result;

            return createProductModel(item)
        } else {
            throw new Error('Data fetch was not successful');
        }
    } catch (error) {
        console.log(`Error fetching product with id ${id}: ` + error);
        throw error;
    }
};

export const fetchProductsByIdRange = async (startId, endId) => {
    try {
        const idArray = [];
        for (let i = startId; i <= endId; i++) {
            idArray.push(i);
        }

        // Tüm ID'ler için API çağrıları oluşturulur
        const productPromises = idArray.map(id => fetchProductById(id));
        const products = await Promise.all(productPromises); // Sonuçları toplamak için Promise.all

        return products;
    } catch (error) {
        console.error(`Error fetching products in range ${startId} to ${endId}:`, error);
        throw error;
    }
};

export const createProductModel = (item) => { // ProductModel olarak başka dosya olarak kullanınca çok hata çıktı.
    return {
        id: item.productId,
        labels: item.categoryName,
        category: item.categoryName,
        img: item.imageUrl,
        hover_img: item.imageUrl,
        title: item.name,
        price: item.price,
        description: item.description,
        rating: {
            rate: Math.floor(Math.random() * 5) + 1,
            count: Math.floor(Math.random() * 999) + 1
        },
        color: [
            {
                color: "green",
                img: item.imageUrl,
                quantity: 1,
            },
            {
                color: "red",
                img: item.imageUrl,
                quantity: 1,
            },
            {
                color: "blue",
                img: item.imageUrl,
                quantity: 1,
            },
        ]
    };
}