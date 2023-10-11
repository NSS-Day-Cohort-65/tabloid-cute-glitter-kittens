import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { createTag } from "../../managers/tagManager.js";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";

export const CreateTag = () => {
    const [name, setName] = useState("");
    const [errors, setErrors] = useState("");
    
    const navigate = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();
        const newTag = {
            name,
        };

        createTag(newTag).then(() => {
     
                navigate("/Tags");
           
        });
    };

    return (
        <div className="container">
            <h2 className="sub-menu">Create Tag</h2>
            <Form>
                <FormGroup>
                    <Label>Name</Label>
                    <Input
                        type="text"
                        placeholder="Name of Tag"
                        onChange={(e) => {
                            setName(e.target.value);
                        }}
                    />
                </FormGroup>
                
                <Button onClick={handleSubmit} color="primary">
                    Submit
                </Button>
            </Form>
            <div style={{ color: "red", background: "lightgray", padding: "1rem ", margin: "2rem 0" }}>
                {Object.keys(errors).map((key) => (
                    <> <p>Error Informaton:</p>
                        <p key={key}>
                            {key}: {errors[key].join(",")}
                        </p>
                    </>
                ))}
            </div>

        </div>

    )
}