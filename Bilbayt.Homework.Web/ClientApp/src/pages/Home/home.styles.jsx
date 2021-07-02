import styled from "styled-components";

export const HomeContainer = styled.div`
  max-width: 768px;
  margin: 0 auto;
  margin-top: 136px;
  padding: 0 15px;
  padding-bottom: 60px;
  padding-top: 54px;

  @media screen and (max-width: 1023px) {
    margin-top: 192px;
  }

  @media screen and (max-width: 767px) {
    margin-top: 238px;
  }

  @media screen and (max-width: 702px) {
    margin-top: 0;
  }
`;
export const ProfileContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
`;
