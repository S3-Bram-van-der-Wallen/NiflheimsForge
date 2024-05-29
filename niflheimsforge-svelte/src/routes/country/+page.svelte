<script lang="ts">
  import { onMount, onDestroy } from 'svelte';
  import { Button } from '@sveltestrap/sveltestrap';

  let isOpen = false;
  export let countries = [];

  async function getCountries() {
    const response = await fetch('niflheimsforge/countries');
    if (response.ok) {
      let newCountries = await response.json();
      countries = newCountries.body;
      console.log(countries);
    } else {
      console.error('Failed to fetch countries')
    }
  }

  onMount(getCountries);

  function toggle(){
  isOpen = !isOpen;
  }
</script>

<style>
  body, html {
  height: 100%;
  }
  .flex-container {
  display: flex;
  height: calc(100vh - 60px);
  }
  .country-navigation {
    flex: 0 0 20%;
    border-style: solid;
    border-width: 2px;
    border-color: green;
  }
  .country-content {
    flex: 1;
    display: flex;
    justify-content: flex-end;
  }
  .dnd-content-manager {
    flex: 0 0 0;
    display: flex;
    justify-content: flex-end;
    background-color: darkgray;
    transition: flex-basis 0.5s ease-in-out;
    overflow: hidden;
  }
  .dnd-content-manager.open {
    flex-basis: 20%
  }
  .topright-button {
    padding: 10px; 
    }
  .bottom-button {
    margin: auto;
    width: 100%;
    bottom: 10px;
    text-align: center;
  }
</style>

  <div class="flex-container">
    <div class="country-navigation">
      All countries:
      <ul>
        {#each countries as country (country.id)}
        <a href='#'>{country.name}</a><br/>
        {/each}
      </ul>
      <div class="bottom-button">
        <Button color="success">
          Create a new country
        </Button>
      </div>
    </div>
    <div class="country-content">
      {#if !isOpen}
        <div class="topright-button">
            <Button on:click={toggle} color="success">
              <span>Manage your D&D content</span>
            </Button>
        </div>
      {/if}
    </div>
    <div class="dnd-content-manager {isOpen ? 'open' : ''}" id="dndContentManager">
      <div class="topright-button">
        <Button on:click={toggle} color="close">
        </Button>
      </div>
    </div>  
  </div>