const _apiUrl = "/api/category"

export const getAllCategories = () => {
    return fetch(_apiUrl).then(res => res.json());
}