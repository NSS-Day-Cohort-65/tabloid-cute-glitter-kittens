import { useEffect, useState } from "react";
import { getUserProfilesWithRoles } from "../../managers/userProfileManager";
import { Link } from "react-router-dom";
import { Table, Button } from "reactstrap";

export default function UserProfileList() {
  const [userProfiles, setUserProfiles] = useState([]);

  const getSetUserProfiles = () => {
    getUserProfilesWithRoles().then(setUserProfiles);
  };

  useEffect(
    getSetUserProfiles
  , [])

  if (!userProfiles) {
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
            
          </tr>
        </thead>
        <tbody>
          {userProfiles.map(up => (
            <tr key={up.id}>
              <th scope='row'>{up.userName}</th>
              <td>{`${up.fullName}`}</td>
              <td>{up.roles}</td>
              <td><Link to={`${up.id}`}><Button>Details</Button></Link></td>

            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  )


}
