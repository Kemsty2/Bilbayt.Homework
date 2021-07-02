import { AuthTitle, AuthSubTitle, AuthText } from "../Login/login.styles";
import { AuthFormContainer } from "../../components/Container/AuthContainer.styles";
import RegisterForm from "../../components/Forms/RegisterForm/register.form";

const RegisterPage = ({ handleSubmit, isLoading }) => {
  return (
    <AuthFormContainer>
      <AuthTitle>SignUp</AuthTitle>
      <AuthSubTitle>SignUp to Bilbayt Homework</AuthSubTitle>
      <AuthText>Please fill this form to register on our platform</AuthText>

      <RegisterForm onSubmit={handleSubmit} isLoading={isLoading} />
    </AuthFormContainer>
  );
};

export default RegisterPage;
