const apiUrl = "/api/tag"

export const getTags = () => {
    return fetch(apiUrl).then((res) => res.json());
};

export const createTag = async (tag) => {
    try {
        const response = await fetch(apiUrl, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(tag)
        });

        if (response.status === 400) {
            // Handle the case where the server responds with a 400 Bad Request
            // This indicates that the tag already exists or there is a validation error.
            const errorResponse = await response.json();
            throw new Error(errorResponse); // Throw the error message from the server.
        }

        // Handle other HTTP status codes if needed.
        throw new Error(`Unexpected response status: ${response.status}`);
    } catch (error) {
        console.error("Error adding a tag:", error);
        throw error;
    }
};

