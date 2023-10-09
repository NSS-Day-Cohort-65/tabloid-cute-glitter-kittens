import { useEffect, useState } from 'react';
import { getAllCategories } from '../../managers/categoryManager';
import { Button, Container, List, ListGroup, ListGroupItem } from 'reactstrap';

export const CategoriesList = () => {
    const [categories, setCategories] = useState([]);

    const loadCategories = () => {
        getAllCategories().then(setCategories);
    }

    const handleDelete = (categoryId) => {
        console.log(`Deleted #${categoryId}`);
    }

    const handleEdit = (categoryId) => {
        console.log(`Edit #${categoryId}`);
    }

    useEffect(() => {
        loadCategories();
    }, [])
    return (
        <Container>
            <List>
                <ListGroup>
                    {categories.length > 0 && categories.map(c => {
                        return (
                            <ListGroupItem key={c.id}>
                                <div style={{ display: "flex", justifyContent: "space-between" }}>
                                    <b>{c.name}</b>
                                    <div>
                                        <Button onClick={() => { handleEdit(c.id) }}>Edit</Button>{" "}
                                        <Button onClick={() => { handleDelete(c.id) }}>Delete</Button>
                                    </div>
                                </div>
                            </ListGroupItem>
                        )
                    })}
                </ListGroup>
            </List>
        </Container>
    );
}