import { useEffect, useState } from "react";
import { deactivateUserById, getUserProfilesWithRoles } from "../../managers/userProfileManager";
import { Link } from "react-router-dom";
import { Table, Button, ModalHeader, ModalBody, Modal, ModalFooter } from "reactstrap";
import UserProfileListActive from "./UserProfileListActive";
import UserProfileListInactive from "./UserProfileListInactive";

export default function UserProfileList() {
  const [activeUsersView, setActiveUsersView] = useState(true);

  return (
    <div className="container">
      <h4 className="sub-menu">User Profiles</h4>
      {activeUsersView ? (
        <>
          <Button onClick={() => setActiveUsersView(false)}>View Deactivated</Button>
          <UserProfileListActive />
        </>
      ) : (
        <>
          <Button onClick={() => setActiveUsersView(true)}>View Active</Button>
          <UserProfileListInactive />
        </>
      )}
    </div>
  )
}
