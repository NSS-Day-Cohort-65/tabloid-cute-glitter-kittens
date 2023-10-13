import { useEffect, useState } from 'react';
import { deleteCategory, getAllCategories } from '../../managers/categoryManager';
import { Button, Container, List, ListGroup, ListGroupItem, Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import { useNavigate } from 'react-router-dom';

export const CategoriesList = () => {
    const [categories, setCategories] = useState([]);
    const [modal, setModal] = useState(false);
    const [categoryToDelete, setCategoryToDelete] = useState({});

    const toggle = () => setModal(!modal);

    const loadCategories = () => {
        getAllCategories().then(setCategories);
    }

    const handleDeleteConfirm = (e, categoryObj) => {
        e.preventDefault();
        setCategoryToDelete(categoryObj);
        toggle();
    }
    
    const handleDelete = (e) => {
        deleteCategory(categoryToDelete.id)
        .then(() => loadCategories());
        toggle();
        
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
                                        <Button onClick={(e) => { handleDeleteConfirm(e, c) }}>Delete</Button>
                                    </div>
                                </div>
                            </ListGroupItem>
                        )
                    })}
                </ListGroup>
            </List>
            <Modal isOpen={modal} toggle={toggle}>
                <ModalHeader>Confirm Delete</ModalHeader>
                <ModalBody>
                    Are you sure you want to delete category "{categoryToDelete.name}"?
                </ModalBody>
                <ModalFooter>
                    <Button onClick={toggle}>No</Button>
                    <Button onClick={() => { handleDelete() }}>Yes</Button>
                </ModalFooter>
            </Modal>
        </Container>
    );
}