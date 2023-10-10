import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { createCategory, getAllCategories } from "../../managers/categoryManager";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";

export default function CreateCategory() {
    const [name, setName] = useState("");
    const [categories, setCategories] = useState([]);

    useEffect(() => {
        getAllCategories().then(setCategories)
    }, []);

    const navigate = useNavigate();

    const handleSubmit = () => {
        const newCategory = {
            name,
        }

        createCategory(newCategory).then(() => {
            navigate('/categories')
            });
        };

    return (
        <>
        <h2>Create a New Cat-egory!</h2>
        <Form>
            <FormGroup>
                <Label>Name</Label>
                <Input
                type="text"
                value={name}
                onChange={(e) => {
                    setName(e.target.value);
                }}
                />
            </FormGroup>
            <Button onClick={handleSubmit} color="primary">
                Save
            </Button>
        </Form>
        </>
    )
}