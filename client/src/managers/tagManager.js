const apiUrl = "/api/tag"

export const getTags = () => {
    return fetch(apiUrl).then((res) => res.json());
};