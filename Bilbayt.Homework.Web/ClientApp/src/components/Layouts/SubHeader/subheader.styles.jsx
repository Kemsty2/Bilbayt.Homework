import styled from "styled-components";

export const SubHeaderContainer = styled.div`
  padding-bottom: 1.5px;
  background-color: #000000;
  margin-bottom: 2.5rem;

  position: fixed;
  top: 90px;
  left: 0;
  width: 100%;
  z-index: 2;

  @media screen and (max-width: 1023px) {
    top: 98px;
  }

  @media screen and (max-width: 702px) {
    position: relative;
    top: unset;
  }
`;

export const SubHeaderContent = styled.nav`
  border-bottom: none;
  margin-bottom: 0;
  border-top: none;
`;
