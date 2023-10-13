import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { createCommentForPost } from "../../managers/commentManager";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";

export default function CreateComment() {
    const [subject, setSubject] = useState("")
    const [content, setContent] = useState("")
    const { postId } = useParams();

    const navigate = useNavigate();

    const handleSave = (e) => {
        e.preventDefault();
        const newComment = {
            subject,
            content,
        };

        createCommentForPost(postId, newComment).then(() => {
            navigate(`/posts/${postId}/comments`)
        });
    };

    return (
        <>
            <Form>
                <FormGroup>
                    <Label>Subject</Label>
                    <Input
                        type="text"
                        value={subject}
                        onChange={(e) => {
                            setSubject(e.target.value);
                        }}
                    />
                    <Label>Content</Label>
                    <Input
                        type="text"
                        value={content}
                        onChange={(e) => {
                            setContent(e.target.value);
                        }}
                    />
                </FormGroup>
                <Button onClick={handleSave} color="primary">
                    Save
                </Button>
            </Form>
        </>
    )
}