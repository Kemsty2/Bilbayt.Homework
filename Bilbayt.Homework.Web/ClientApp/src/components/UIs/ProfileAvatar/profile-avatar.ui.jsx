import {
  AvatarContainer,
  AvatarContent,
  AvatarImage,
  AvatarName,
} from "./profile-avatar.styles";

import defaultUser from "../../../assets/images/default-user.jpg";

const ProfileAvatar = ({ name }) => {
  return (
    <AvatarContainer>
      <AvatarContent>
        <AvatarImage src={defaultUser} className="img-fluid" />
      </AvatarContent>
      <AvatarName>{name}</AvatarName>
    </AvatarContainer>
  );
};

export default ProfileAvatar;
