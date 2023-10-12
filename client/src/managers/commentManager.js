const apiUrl = "/api/comment"

export const getCommentsForPost = (postId) => {
    return fetch(`${apiUrl}/post/${postId}`).then((res) => res.json());
};