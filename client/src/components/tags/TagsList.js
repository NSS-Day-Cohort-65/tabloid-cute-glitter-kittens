import { useEffect, useState } from "react";
import { getTags } from "../../managers/tagManager";
import { Button, Table } from "reactstrap";

export default function TagsList() {
    const [tags, setTags] = useState([])

    useEffect(() => {
        getTags().then(setTags)
    }, [])

    return (
        <>
        <Table>
            <thead>
                <tr>
                <Button>Add New Tag</Button>
                    <th>Name</th>
                </tr>
            </thead>
            <tbody>
                {tags.map((t) => (
                    <tr key={t.id}>
                        <th scope="row">{`${t.name}`}</th>
                        <Button>Delete Tag</Button>
                        <Button>Edit Tag</Button>
                    </tr>
                ))}
            </tbody>
        </Table>
        </>
    )
}