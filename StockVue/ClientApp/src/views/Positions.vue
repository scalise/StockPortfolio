<template>
    <v-container fluid>
        <v-layout column align-center>
            <h1>Positions {{ positions.length }}</h1>
            <StockPositions :items="positions"/>
        </v-layout>
    </v-container>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import StockPositions from '@/components/StockPositions.vue'; // @ is an alias to /src    

    @Component({
        components: {
            StockPositions,            
        },
    })
    export default class Positions extends Vue {

        public positions: Object[] = [];

        async mounted() {
            console.log("mounted");
            if (this.$store.getters['positions/positionCount'] == 0) {
                this.fetchData();
                this.positions = this.$store.getters['positions/getAll'];
            }
        }

        public fetchData(): void {
            this.$store.dispatch("positions/loadStockPositions");
        }
    }

</script>
