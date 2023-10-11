import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { getCommentsForPost } from "../../managers/commentManager";
import { Card, CardBody, CardHeader, Container, ListGroup, ListGroupItem } from "reactstrap";
import { getPostById } from "../../managers/postManager";

export default function CommentsList() {
    const { postId } = useParams();
    const [comments, setComments] = useState([]);
    const [post, setPost] = useState(null);

    useEffect(() => {
        getPostById(postId)
        .then(setPost)
        getCommentsForPost(postId)
        .then(setComments)
    }, [postId])

    return (
        <Container>
            <div>
                {post && (
                    <Card>
                        <CardHeader>
                            <h2>{post.title}</h2>
                        </CardHeader>
                        <CardBody>
                            <p>{post.content}</p>
                        </CardBody>
                    </Card>
                )}

                <h3>Comments</h3>
                {comments.length > 0 ? (
                <ListGroup>
                    {comments.map(c => (
                        <ListGroupItem key={c.id}>
                            <h5>{c.subject}</h5>
                            <p>{c.content}</p>
                            <p><strong>Author:</strong> {c.userProfile.userName}</p>
                            <p><strong>Posted:</strong> {new Date(c.createDateTime).toLocaleDateString()}</p>
                        </ListGroupItem>
                    ))}
                </ListGroup>
                ) : (
                    <p>No comments available</p>
                )}
                <Link to={"/posts"}>Return To Posts</Link>
            </div>
        </Container>
    )

}