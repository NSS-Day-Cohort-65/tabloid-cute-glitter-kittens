const _apiUrl = "/api/post";

export const getAllPosts = () => {
    return fetch(_apiUrl).then((res) => res.json());
}
//categoryId is int
export const getAllPostsByCategory = (categoryId) => {
    console.log('category: ' + categoryId)
    return fetch(`${_apiUrl}?categoryId=${categoryId}`)
    .then((res) => {
        if (!res.ok) {
            throw new Error('No posts with selected category :(');
        }
        return res.json();
    });
}

//tagId is int
export const getAllPostsByTag = (tagId) => {
    console.log('tag: ' + tagId)
    return fetch(`${_apiUrl}?tagId=${tagId}`)
        .then((res) => {
            if (!res.ok) {
                throw new Error('No posts with selected tag :(');
            }
            return res.json();
        });
}

export const getPostById = (id) => {
    return fetch(_apiUrl + `/${id}`).then((res) => res.json());
};

export const createPost = (post) => {
    return fetch(_apiUrl,
        {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(post)
        }).then(res => res.json())
}