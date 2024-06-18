<script lang="ts">
    import { Navbar, NavbarBrand, Nav, NavItem, NavLink } from '@sveltestrap/sveltestrap'; 
  </script>
  
  <Navbar color="success" dark>
    <NavbarBrand href="/">NiflheimsForge Worldbuilder</NavbarBrand>
        <Nav class="ms-auto" navbar>
            <NavItem>
                <NavLink href="countries/">Countries</NavLink>
            </NavItem>
        </Nav>
  </Navbar>
  <slot />