import { useEffect, useState } from "react";
import { getInactiveUserProfilesWithRoles, reactivateUserById } from "../../managers/userProfileManager";
import { Link } from "react-router-dom";
import { Table, Button } from "reactstrap";

export default function UserProfileListInactive () {
    const [userProfiles, setUserProfiles] = useState([]);

    const populateUserProfiles = () => {
        getInactiveUserProfilesWithRoles().then(setUserProfiles);
    };

    useEffect(() => {
        populateUserProfiles()
    }, 
    []);

    // const handleDeactivateInitial = (e, user) => {
    //     e.preventDefault();
    //     setSelectedUserObj(user)
    //     toggleModal();
    // }

    // const handleDeactivate = (e) => {
    //     e.preventDefault();
    //     deactivateUserById(selectedUserObj.id)
    //     .then(() => toggleModal())
    //     .then(() => populateUserProfiles())
    // }

    const handleReactivate = (e, user) => {
        e.preventDefault();
        console.log(user.id);
        reactivateUserById(user.id)
        .then(() => populateUserProfiles())
    }

    if (userProfiles.length === 0) {
        return null;
    }
    return (
        <>
        <Table>
            <thead>
            <tr>
                <th>Username</th>
                <th>Name</th>
                <th>Roles</th>
                <th>Details</th>
                <th>Reactivate</th>
            </tr>
            </thead>
            <tbody>
            {userProfiles.map(up => (
                <tr key={up.id}>
                <th scope='row'>{up.userName}</th>
                <td>{`${up.fullName}`}</td>
                <td>{up.roles}</td>
                <td><Link to={`${up.id}`}><Button>Details</Button></Link></td>
                <td><Button color="success" onClick={(e) => handleReactivate(e, up)}>Un-Destroy</Button></td>
                </tr>
            ))}
            </tbody>
        </Table>
        </>
    )
}