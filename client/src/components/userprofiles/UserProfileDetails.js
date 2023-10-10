import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getUserById } from "../../managers/userProfileManager";
import defaultCatImage from '../../assets/defaultcat.png';

export default function UserProfileDetails() {
  const [userProfile, setUserProfile] = useState({});

  const { id } = useParams();

  useEffect(() => {
    getUserById(id).then(setUserProfile);
  }, [id]);

  const convertDateTimeString = (dateTimeString) => {
    const inputDate = new Date(dateTimeString);

    const month = String(inputDate.getMonth() + 1).padStart(2, "0");
    const day = String(inputDate.getDate()).padStart(2, "0");
    const year = inputDate.getFullYear();

    return `${month}/${day}/${year}`
  }

  const convertRolesToString = (rolesArray) => {
    if (rolesArray && rolesArray.length > 0) {
      return rolesArray.join(", ");
    } else {
      return "none specified"
    }
  }

  if (!userProfile) {
    return null;
  }
  return (
    <>
      <img src={userProfile.imageLocation} alt={defaultCatImage} />
      <h3>{userProfile.fullName}</h3>
      <p>Display name: {userProfile.userName}</p>
      <p>Email: {userProfile.email}</p>
      <p>Join date: {convertDateTimeString(userProfile.createDateTime)}</p>
      <p>Profile type: {convertRolesToString(userProfile?.roles)}</p>
    </>
  );
}