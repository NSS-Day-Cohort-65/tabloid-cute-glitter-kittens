import { useEffect, useState } from "react";
import { deactivateUserById, getUserProfilesWithRoles } from "../../managers/userProfileManager";
import { Link } from "react-router-dom";
import { Table, Button, ModalHeader, ModalBody, Modal, ModalFooter } from "reactstrap";

export default function UserProfileList() {
  const [userProfiles, setUserProfiles] = useState([]);
  const [modal, setModal] = useState(false);
  const [selectedUserObj, setSelectedUserObj] = useState({});

  const populateUserProfiles = () => {
    getUserProfilesWithRoles().then(setUserProfiles);
  };

  useEffect(() => {
    populateUserProfiles()
  }, 
  []);

  const toggleModal = () => {setModal(!modal)};

  const handleDeactivateInitial = (e, user) => {
    e.preventDefault();
    setSelectedUserObj(user)
    console.log(user)
    toggleModal();
  }

  const handleDeactivate = (e) => {
    e.preventDefault();
    deactivateUserById(selectedUserObj.id)
    .then(() => toggleModal())
    .then(() => populateUserProfiles())
  }

  if (userProfiles.length === 0) {
    return null;
  }

  return (
    <div className="container">
      <h4 className="sub-menu">User Profiles</h4>
      <Table>
        <thead>
          <tr>
            <th>Username</th>
            <th>Name</th>
            <th>Roles</th>
            <th>Details</th>
            <th>Deactivate</th>
          </tr>
        </thead>
        <tbody>
          {userProfiles.map(up => (
            <tr key={up.id}>
              <th scope='row'>{up.userName}</th>
              <td>{`${up.fullName}`}</td>
              <td>{up.roles}</td>
              <td><Link to={`${up.id}`}><Button>Details</Button></Link></td>
              <td><Button color="danger" onClick={(e) => handleDeactivateInitial(e, up)}>Destroy</Button></td>
            </tr>
          ))}
        </tbody>
      </Table>
      <Modal isOpen={modal}>
        <ModalHeader>Deactivate user</ModalHeader>
        <ModalBody>
          Are you sure you want to deactivate user {selectedUserObj.fullName}?
        </ModalBody>
        <ModalFooter>
          <Button color="warning" onClick={(e) => handleDeactivate(e)}>
            Yes; destroy.
          </Button>
          <Button onClick={() => toggleModal()}>
            No!!
          </Button>
        </ModalFooter>
      </Modal>
    </div>
  )


}
