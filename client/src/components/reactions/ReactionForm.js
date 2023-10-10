import { useEffect, useState } from "react";
import { createReaction, getReactions } from "../../managers/reactionManager";
import { useNavigate } from "react-router-dom";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";

export default function CreateReaction() {
    const [name, setName] = useState("");
    const [imageLocation, setImageLocation] = useState("");
    const [reactions, setReactions] = useState([])

    useEffect(() => {
        getReactions().then(setReactions)
    }, []);

    const navigate = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();
        const newReaction = {
            name,
            imageLocation,
        }

        createReaction(newReaction).then(() => {
            navigate("/reactions")
        });
    };

    return (
        <>
        <h2>Add a New Reaction!</h2>
        <Form>
            <FormGroup>
                <Label>Reaction Name</Label>
                <Input
                type="text"
                value={name}
                onChange={(e) => {
                    setName(e.target.value);
                }}
                />
                <Label>Reaction Image</Label>
                <Input
                type="text"
                value={imageLocation}
                onChange={(e) => {
                    setImageLocation(e.target.value);
                }}
                />
            </FormGroup>
            <Button onClick={handleSubmit} color="primary">
                Save Reaction
            </Button>
        </Form>
        </>
    )
}