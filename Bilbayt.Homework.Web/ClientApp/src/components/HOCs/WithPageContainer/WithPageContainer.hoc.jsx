import { MainContainer } from "./WithPageContainer.styles";
import Header from "../../Layouts/Header/header.layout";
import Footer from "../../Layouts/Footer/footer.layout";
import SubHeader from "../../Layouts/SubHeader/subheader.layout";

const WithPageContainer =
  (WrapperComponent) =>
  ({ ...props }) => {
    return (
      <>
        <Header />
        <MainContainer>
          <SubHeader />
          <WrapperComponent {...props} />
        </MainContainer>
        <Footer />
      </>
    );
  };

export default WithPageContainer;
