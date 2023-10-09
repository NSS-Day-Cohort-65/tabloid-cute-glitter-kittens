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
                    <th>Name</th>
                </tr>
            </thead>
            <tbody>
                {tags.map((t) => (
                    <tr key={t.id}>
                        <th scope="row">{`${t.name}`}</th>
                        <Button>Add New Tag</Button>
                        <Button>Delete Tag</Button>
                        <Button>Edit Tag</Button>
                    </tr>
                ))}
            </tbody>
        </Table>
        </>
    )
}