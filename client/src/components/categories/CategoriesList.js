import { useEffect, useState } from 'react';
import { getAllCategories } from '../../managers/categoryManager';
import { Button, Container, List, ListGroup, ListGroupItem } from 'reactstrap';
import { Link, useNavigate } from 'react-router-dom';

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

    const navigate = useNavigate()

    const handleNavigate = (e) => {
        e.preventDefault()
        navigate('create')
    } 

    useEffect(() => {
        loadCategories();
    }, [])

    return (
        <Container>
            <List>
                <ListGroup>
                    <Button onClick={(e) => {handleNavigate(e)}}>Create Category</Button>
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