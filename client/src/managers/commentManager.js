const apiUrl = "/api/comment"

export const getCommentsForPost = (postId) => {
    return fetch(`${apiUrl}/post/${postId}`).then((res) => res.json());
};

export const createCommentForPost = (postId, comment) => {
    return fetch(`${apiUrl}/post/${postId}`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(comment),
    })
}