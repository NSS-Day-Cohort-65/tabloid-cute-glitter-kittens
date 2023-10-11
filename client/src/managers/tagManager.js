const apiUrl = "/api/tag"

export const getTags = () => {
    return fetch(apiUrl).then((res) => res.json());
};

export const createTag = (tag) => {
    return fetch(apiUrl, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(tag)
    }).then((res) => res.json());
};