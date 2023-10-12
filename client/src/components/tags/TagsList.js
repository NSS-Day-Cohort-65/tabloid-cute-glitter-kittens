import { useEffect, useState } from "react";
import { getTags } from "../../managers/tagManager";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom"

export default function TagsList() {
    const [tags, setTags] = useState([])

    useEffect(() => {
        getTags().then(setTags)
    }, [])

    return (
        <div className="container">
            <div className="sub-menu">
                <h4 >Tag Management</h4>
                <Link to="create" style={{margin:"0 1rem"}}> <Button>Add New Tag</Button></Link>
            </div>

            <Table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Delete</th>
                        <th>Edit</th>
                    </tr>
                </thead>
                <tbody>
                    {tags.map((t) => (
                        <tr key={t.id}>
                            <th scope="row">{`${t.name}`}</th>
                            <td><Button>Delete Tag</Button></td>
                            <td><Button>Edit Tag</Button></td>
                        </tr>
                    ))}
                </tbody>
            </Table>

        </div>
    )
}