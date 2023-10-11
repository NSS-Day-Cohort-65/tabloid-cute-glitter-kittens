const apiUrl = "/api/reaction"

export const getReactions = () => {
    return fetch(apiUrl).then(res => res.json());
};

export const createReaction = (reaction) => {
    return fetch(apiUrl, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(reaction)
    }).then((res) => res.json());
};