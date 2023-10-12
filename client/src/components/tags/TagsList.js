import { useEffect, useState } from "react";
import { getTags } from "../../managers/tagManager";
import { Table, Button, ModalHeader, ModalBody, Modal, ModalFooter } from "reactstrap";
import { Link } from "react-router-dom"

export default function TagsList() {
    const [tags, setTags] = useState([])
    const [modal, setModal] = useState(false);
    const [selectedTag, setSelectedTag] = useState([]);

    useEffect(() => {
        getTags().then(setTags)
    }, [])

    const toggleModal = () => { setModal(!modal) };

    const handleDelete = (tag) => {
        toggleModal();
        setSelectedTag(tag);
        console.log(`set to ${tag.id}`)
    }

    const handleConfirmedDelete = () => {
        console.log(`deleted ${selectedTag.name} `)
        toggleModal()
        //getTags.then(setTags)
    }

    return (
        <div className="container">
            <div className="sub-menu">
                <h4 >Tag Management</h4>
                <Link to="create" style={{ margin: "0 1rem" }}> <Button>Add New Tag</Button></Link>
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
                            <td>
                                <Button onClick={() => { handleDelete(t) }}>
                                    Delete Tag
                                </Button>
                            </td>
                            <td><Button>Edit Tag</Button></td>
                        </tr>
                    ))}
                </tbody>
            </Table>

            <Modal isOpen={modal}>
                <ModalHeader>Delete Tag</ModalHeader>

                <ModalBody>
                    Are you sure you want to delete #{selectedTag.name} ?
                </ModalBody>

                <ModalFooter>
                    <Button color="warning" onClick={() => handleConfirmedDelete()}>
                        Ok
                    </Button>
                    <Button onClick={() => toggleModal()}>
                        No
                    </Button>
                </ModalFooter>
            </Modal>

        </div>
    )
}