import { HomeContainer, ProfileContainer } from "./home.styles";

import ProfileAvatar from "../../components/UIs/ProfileAvatar/profile-avatar.ui";
import ProfileForm from "../../components/Forms/ProfileForm/profile.form";

const HomePage = ({ profile }) => {
  return (
    <HomeContainer>
      <ProfileContainer>
        <ProfileAvatar name={profile.userName} />
      </ProfileContainer>
      <h3 className="custom-title">
        <span>Profil</span>
      </h3>
      <ProfileForm profile={profile} />
    </HomeContainer>
  );
};

export default HomePage;
