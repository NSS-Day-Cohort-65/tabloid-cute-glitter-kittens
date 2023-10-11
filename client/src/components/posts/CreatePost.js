import { useState } from 'react';
import { Button, Container, Form, FormGroup, Input, Label } from 'reactstrap';
import { createPost } from '../../managers/postManager';
import { useNavigate } from 'react-router-dom';
import { getAllCategories } from '../../managers/categoryManager';

export default function CreatePost({ loggedInUser }) {
    const [postBuilder, setPostBuilder] = useState(
        {
            title: "",
            content: "",
            categoryId: 0,
            imageLocation: "",
            userProfileId: loggedInUser.id,
        }
    )
    const [categories, setCategories] = useState([]);

    useState(() => {
        getAllCategories().then(setCategories);
    }, [])

    const navigate = useNavigate();

    const handleSave = () => {
        createPost(postBuilder).then(() => { navigate("/posts") })
    };

    const updatePostBuilder = (key, e) => {
        e.preventDefault();

        const copy = { ...postBuilder };
        copy[key] = e.target.value;
        setPostBuilder(copy);
    }

    if (categories.length === 0) return null;

    return (
        <Container style={{ padding: "1rem" }}>
            <Form>
                <FormGroup>
                    <Label>Title</Label>
                    <Input type='text' value={postBuilder.title} onChange={e => updatePostBuilder("title", e)} />
                    <Label>Content</Label>
                    <Input type='text' value={postBuilder.content} onChange={e => updatePostBuilder("content", e)} />
                    <Label>Category</Label>
                    <Input type='select' value={postBuilder.categoryId} onChange={e => updatePostBuilder("categoryId", e)}>
                        <option value={0}>Select a category...</option>
                        {
                            categories.map((c) => {
                                return (
                                    <option key={c.id} value={c.id}>{c.name}</option>
                                )
                            })
                        }
                    </Input>
                    <Label>Header Image Url</Label>
                    <Input type='text' value={postBuilder.imageLocation} onChange={e => updatePostBuilder("imageLocation", e)}></Input>
                    <Label>Publish Date</Label>
                    <Input type='date' value={postBuilder.publishDateTime} onChange={e => updatePostBuilder("publishDateTime", e)}></Input>
                </FormGroup>
                <Button onClick={() => handleSave()}>Save</Button>
            </Form>
        </Container>
    )
};