import { HomeContainer, ProfileContainer } from "./home.styles";

import ProfileAvatar from "../../components/UIs/ProfileAvatar/profile-avatar.ui";
import ProfileForm from "../../components/Forms/ProfileForm/profile.form";

const HomePage = () => {
  return (
    <HomeContainer>
      <ProfileContainer>
        <ProfileAvatar name="Kemgne Steeve" />
      </ProfileContainer>
      <h3 className="custom-title">
        <span>Profil</span>
      </h3>
      <ProfileForm />
    </HomeContainer>
  );
};

export default HomePage;
